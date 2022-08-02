using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[,] Matrix1 = new int[,] {
                 {1, 2, 3, 4, 5},
                 {6, 7, 8, 9, 10},
                 {11, 12, 13, 14, 15},
                 {16, 17, 18, 19, 20},
                 {21, 22, 23, 24, 25},
                 };

            int[,] Matrix2 = new int[,] {
                 {1, 2, 3, 4, 5},
                 {6, 7, 8, 9, 10},
                 {11, 12, 13, 14, 15},
                 {16, 17, 18, 19, 20},
                 {21, 22, 23, 24, 25},
                 };


            MatrixTranspose(Matrix1);
            Rotate(Matrix1);
            MatrixMultiply(Matrix1, Matrix2);

        }

        static void MatrixTranspose(int[,] Matrix1)
        {
            int mHeight = Matrix1.GetLength(0);
            int mWidth = Matrix1.GetLength(1);

            int temp = 0;
            for (int i = 0; i < mWidth; i++)
            {
                for (int j = i; j < mHeight; j++)
                {
                    temp = Matrix1[i, j];
                    Matrix1[i, j] = Matrix1[j, i];
                    Matrix1[j, i] = temp;
                    Console.Write(temp + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        static void Rotate(int [,] Matrix1)
        {
            int m = Matrix1.GetLength(0);
            int n = Matrix1.GetLength(1);

            int[,] res = new int[m, n];
            
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; j++)
                {
                    res[j,n - i - 1] = Matrix1[i, j];
                    Console.Write(Matrix1[i,j] +" ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        
        static void MatrixMultiply(int[,] Matrix1, int[,] Matrix2)
        {
            int dimension1=Matrix1.GetLength(0);
            int dimension2=Matrix1.GetLength(1);
            int dimension3=Matrix2.GetLength(0);
            int dimension4=Matrix2.GetLength(1);
            int[,] Matrix3 = new int[dimension1, dimension4];
            int temp = 0;

            if (dimension2 != dimension3)
            {
                Console.WriteLine("matrix can not be multiplied");
            }
            else
            {
                for(int i = 0;i< dimension1; i++)
                {
                    for(int j = 0;j< dimension4; j++)
                    {
                        temp = 0;
                        for (int k = 0;k < dimension2; k++)
                        {
                            temp = Matrix1[i, k] * Matrix2[k, j];
                        }   
                        Matrix3[i, j] = temp;
                        Console.Write(Matrix3[i,j]+" ");
                    }
                    Console.WriteLine();
                    Console.ReadLine();
                }
                
            }
        }
        
    }
}
