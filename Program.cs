using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;

namespace SiećNeuronowa
{
  class Neuron
  {
    public double[] Weights { get; set; }
    public Neuron(int size)
    {
      Weights = new double[size];
    }
    public double FunctionU(double[] X)
    {
      double temp = 0 ;
      for (int i = 0; i < X.Length; i++)
      {
        temp += Weights[i] * X[i];
      }
      return temp;
    }
    public double Signum(double U) => U < 0 ? -1 : 1;
  }


  class Program
  {

    static void Main(string[] args)
    {
      var Siec = new Neuron[3];
      for (int i = 0; i < 3; i++)
      {
        Siec[i] = new Neuron(3);
      }
      bool work = false;
      int check = 0;
      int k = 0;
      var X = new List<double[]>();

      X.Add(new double[] { 10, 2, -1 });
      X.Add(new double[] { 2, -5, -1 });
      X.Add(new double[] { -5, 5, -1 });
      var D = new List<double[]>();
      
        D.Add(new double[]  { 1, -1, -1 });
        D.Add(new double[]  {-1,1,-1 }   );
      D.Add(new double[] { -1, -1, 1 });
      
      Siec[0].Weights = new double[] { 1, 2, 0 };
      Siec[1].Weights = new double[] { 0, -1, 2 };
      Siec[2].Weights = new double[] { 1, 3, -1 };

      int count = 0;
      do
      {
        work = true;
        for (int i = 0; i < 3; i++)
        {
          count++;
          if (D.ElementAt(k)[i] != Siec[i].Signum(Siec[i].FunctionU(X.ElementAt(k))))
          {
            double a = ((D.ElementAt(k)[i] - Siec[i].Signum(Siec[i].FunctionU(X.ElementAt(k)))) * 0.5);
            var temp1 = X.ElementAt(k).Select(x => x * a).ToArray();
            for (int j = 0; j < 3; j++)
            {
              Siec[i].Weights[j] += temp1[j];
              check = 0;
            }
            
          }
          else check++;
          if (check == 4) work = false;
        }

      } while (work);
      Console.WriteLine(count);
    }
  }
}
