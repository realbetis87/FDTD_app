using System;
using System.IO;

namespace FDTD_app
{
    class TEmode2D
    {
        private static double e0 = 8.85418781762e-12;
        private static double m0 = 4 * Math.PI * 1e-7;

        private static double c0 = 1 / Math.Sqrt(m0 * e0);

        private double freq, bw;
        private int c2l;
        public double dx, dy, dt, ta;

        public int M, N;


        private double[,] epsilon, mu, sigma;
        private double[,] Ca, Cb, Da, Db, Ex, Ey, Hz, pHl, pHr, pHt, pHb;

        private int pmlc = 16;
        private double r = 1e-4, nn, smax;

        private double[] e_s, h_s;

        private int[,] posEx, posEy;
        private double[] ampEx, ampEy;
        private int sourcesEx, sourcesEy;

        //Graphene
        private double[] Jgrx, Jgry;
        private double Amc, Gamma;


        public double InitializeDomain(CoreForm.domain dm1)
        {
            this.bw = dm1.bw;
            this.freq = dm1.freq;
            this.c2l = dm1.c2l;

            ta = 3 / (Math.PI * this.bw);

            var l0 = c0 / this.freq;
            dx = l0 / this.c2l;

            dy = dx;

            dt = .99 / c0 / Math.Sqrt(1 / dx / dx + 1 / dy / dy);

            // PML
            nn = 3;
            e_s = new double[pmlc];
            h_s = new double[pmlc];

            smax = -Math.Log(r) * (nn + 1) * e0 * c0 / 2 / dx / pmlc;

            for (int i = 0;i< pmlc; i++)
            {
                e_s[i] = smax * Math.Pow((double)i, nn) / Math.Pow(pmlc - 1, nn);
                h_s[i] = smax * Math.Pow((double)i + .5, nn) / Math.Pow(pmlc - 1, nn) * m0 / e0;
            }

            N = (int)Math.Round(dm1.limits[0] / dx);
            M = (int)Math.Round(dm1.limits[1] / dy);

            return dx;
        }


        public void MakeMedium(Materials.material[] mat, int[,] voxel_matrix)
        {

            var voxel_final = CoreForm.resizePixels(voxel_matrix, N, M);

            /*
            using (TextWriter tw = new StreamWriter("C:\\Users\\OFADC\\Desktop\\fd\\f.txt"))
            {
                for (int i = 0; i < voxel_final.GetLength(0); i++)
                {
                    for (int k = 0; k < voxel_final.GetLength(1); k++)
                    {
                        tw.Write(voxel_final[i, k] + ",");
                    }
                    tw.WriteLine();

                }
            }
            */


            epsilon = new double[N, M];
            mu = new double[N, M];
            sigma = new double[N, M];

            Ca = new double[N, M];
            Cb = new double[N, M];
            Da = new double[N, M];
            Db = new double[N, M];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    epsilon[i, j] = e0*mat[voxel_final[i,j]-1].er;
                    mu[i, j] = m0 * mat[voxel_final[i, j]-1].mr;
                    sigma[i, j] = mat[voxel_final[i, j]-1].sigma;

                    Ca[i, j] = (1 - sigma[i, j] * dt / 2 / epsilon[i, j]) / (1 + sigma[i, j] * dt / 2 / epsilon[i, j]);
                    Cb[i, j] = (dt / epsilon[i, j]) / (1 + sigma[i, j] * dt / 2 / epsilon[i, j]);
                    Da[i, j] = 1;
                    Db[i, j] = dt / mu[i, j];
                }
            }


        }

        public void InitializeComponents()
        {
            Ex = new double[N, M];
            Ey = new double[N, M];
            Hz = new double[N, M];

            pHl = new double[pmlc, M];
            pHr = new double[pmlc, M];
            pHt = new double[N, pmlc];
            pHb = new double[N, pmlc];
        }


        public void SourceDefinition(Source.sources[] source, double[,] limits)
        {
            sourcesEx = 0;
            sourcesEy = 0;

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i].orientation == "Ex")
                {
                    sourcesEx++;
                }
                else
                {
                    sourcesEy++;
                }
            }


            ampEx = new double[sourcesEx]; posEx = new int[sourcesEx, 2]; int iex = 0;
            ampEy = new double[sourcesEy]; posEy = new int[sourcesEy, 2]; int iey = 0;



            for (int i = 0; i < source.Length; i++)
            {
                if (source[i].orientation == "Ex")
                {
                    posEx[iex, 0] = (int)Math.Round((source[i].position[0] - limits[0, 0]) / (limits[0, 1] - limits[0, 0]) * (N - 1));
                    posEx[iex, 1] = (int)Math.Round((source[i].position[1] - limits[1, 0]) / (limits[1, 1] - limits[1, 0]) * (M - 1));

                    ampEx[iex] = source[i].amplitude;
                    iex++;
                }
                else
                {
                    posEy[iey, 0] = (int)Math.Round((source[i].position[0] - limits[0, 0]) / (limits[0, 1] - limits[0, 0]) * (N - 1));
                    posEy[iey, 1] = (int)Math.Round((source[i].position[1] - limits[1, 0]) / (limits[1, 1] - limits[1, 0]) * (M - 1));

                    ampEy[iey] = source[i].amplitude;
                    iey++;
                }
            }
        }

        public void GrapheneDefinition()
        {
            Jgrx = new double[M];
            Amc = 2.3546e+10;
            Gamma = 4.5578e+0;
        }

        public void Simulation()
        {
            double J;

            for (int n = 1; n <= 3000; n++)
            {

                J = Math.Exp(-Math.Pow((dt * (double)n - 3 * ta) / ta, 2)) * Math.Sin(2 * Math.PI * freq * (dt * n - 3 * ta));

                for (int i = 0; i < N - 1; i++)
                {
                    for (int j = 0; j < M - 1; j++)
                    {
                        Hz[i, j] = Da[i, j] * Hz[i, j] + Db[i, j] * ((Ex[i, j + 1] - Ex[i, j]) / dy - (Ey[i + 1, j] - Ey[i, j]) / dx);
                    }
                }
                
                for(int i = 0; i < N - 1; i++)
                {
                    for(int j = 0; j < pmlc - 1; j++)
                    {
                        pHb[i, j] = (Da[i, j] - dt / m0 * h_s[pmlc - 2 - j]) * pHb[i, j] + dt / m0 * h_s[pmlc - 2 - j] * Db[i, j] * (Ex[i, j + 1] - Ex[i, j]) / dy;
                        Hz[i, j] = Hz[i, j] - pHb[i, j];
                    }
                }

                for(int i = 0; i < N - 1; i++)
                {
                    for (int j = M - pmlc; j < M - 1; j++)
                    {
                        pHt[i, j - M + pmlc] = (Da[i, j] - dt / m0 * h_s[j - M + pmlc]) * pHt[i, j - M + pmlc] + dt / m0 * h_s[j - M + pmlc] * Db[i, j] * (Ex[i, j + 1] - Ex[i, j]) / dy;
                        Hz[i, j] = Hz[i, j] - pHt[i, j - M + pmlc];
                    }
                }
                
                for(int i = 0; i < pmlc - 1; i++)
                {
                    for(int j = 0; j < M-1; j++)
                    {
                        pHl[i, j] = (Da[i, j] - dt / m0 * h_s[pmlc - 2 - i]) * pHl[i, j] - dt / m0 * h_s[pmlc - 2 - i] * Db[i, j] * (Ey[i + 1, j] - Ey[i, j]) / dx;
                        Hz[i, j] = Hz[i, j] - pHl[i, j];
                    }
                }

                for(int i = N - pmlc; i < N - 1; i++)
                {
                    for(int j = 0; j < M-1; j++)
                    {
                        pHr[i - N + pmlc, j] = (Da[i, j] - dt / m0 * h_s[i - N + pmlc]) * pHr[i - N + pmlc, j] - dt / m0 * h_s[i - N + pmlc] * Db[i, j] * (Ey[i + 1, j] - Ey[i, j]) / dx;
                        Hz[i, j] = Hz[i, j] - pHr[i - N + pmlc, j];
                    }
                }


                for (int i = 0; i < M; i++)
                {
                    Jgry[i] = Jgry[i] * (1- Gamma * dt) / (1+ Gamma * dt) + Ey[N / 2, i] * Amc * dt / (1+ Gamma * dt);
                }




                for (int i = 0; i < N; i++)
                {
                    for(int j = 1; j < M; j++)
                    {
                        Ex[i, j] = Ca[i, j] * Ex[i, j] + Cb[i, j] * (Hz[i, j] - Hz[i, j - 1]) / dy;
                    }
                }

                for(int i = 0; i < N; i++)
                {
                    for (int j = 0; j < pmlc; j++)
                    {
                        Ex[i, j] = Ex[i, j] - dt / e0 * e_s[pmlc - 1 - j] * Ex[i, j];
                    }
                }

                for(int i = 0; i < N; i++)
                {
                    for(int j = M - pmlc; j < M; j++)
                    {
                        Ex[i, j] = Ex[i, j] - dt / e0 * e_s[j - M + pmlc] * Ex[i, j];
                    }
                }








                for (int i = 1; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        Ey[i, j] = Ca[i, j] * Ey[i, j] + Cb[i, j] * (Hz[i - 1, j] - Hz[i, j]) / dx;
                    }
                }

                for(int i = 0; i < pmlc; i++)
                {
                    for(int j = 0; j < M; j++)
                    {
                        Ey[i, j] = Ey[i, j] - dt / e0 * e_s[pmlc - 1 - i] * Ey[i, j];
                    }
                }

                for(int i = N - pmlc; i < N; i++)
                {
                    for(int j = 0; j < M; j++)
                    {
                        Ey[i, j] = Ey[i, j] - dt / e0 * e_s[i - N + pmlc] * Ey[i, j];
                    }
                }

                for (int i = 0; i < M; i++)
                {
                    Ey[N / 2, i] =  Ey[N / 2, i] - dt / e0 / dx * Jgry[i];
                }

                // Sources
                for (int i = 0; i < sourcesEx; i++)
                {
                    Ex[posEx[i,0], posEx[i, 1]] = Ex[posEx[i, 0], posEx[i, 1]] + dt / e0 * J * ampEx[i];
                }

                for (int i = 0; i < sourcesEy; i++)
                {
                    Ey[posEy[i, 0], posEy[i, 1]] = Ey[posEy[i, 0], posEy[i, 1]] + dt / e0 * J * ampEy[i];
                }


                // Saving
                if (n%4==0)
                {
                    using (TextWriter tw = new StreamWriter("C:\\Users\\OFADC\\Desktop\\fd\\sim_dat\\f" + n.ToString("D4") + ".txt"))
                    {
                        for (int i = 0; i < N; i++)
                        {
                            for (int k = 0; k < M; k++)
                            {
                                tw.Write(Ex[i, k] + " ");
                            }
                            tw.WriteLine();
                        }
                    }
                }
                

            }

            Console.WriteLine("Simulation ended.");
            





        }


    }
}
