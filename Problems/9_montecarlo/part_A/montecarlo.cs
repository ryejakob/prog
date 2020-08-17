using System;
using static System.Math;
using static vector;

public class montecarlo{
	
	//this does not seem to work try somthing else (use same number more then once...
	//a function that yeilds a radom point in the integration area:
	public static vector randomx(vector a, vector b){
	var ra = new Random(); 
	vector v= new vector(a.size);
	for(int i=0; i<a.size; i++){
		v[i]=a[i]+ra.NextDouble()*(b[i]-a[i]); //Note ra.NextDouble gives a random double between 0 and 1
		}//end for 
	// System.Console.Error.WriteLine($"{v[0]}");
	return v;
	}//end randomx...
	

	public static vector plainmc(Func<vector,double> f, vector a, vector b, int N){
	//the volume is calculated as:
	double vol=1;
	for(int i=0; i<a.size; i++){
		vol=vol*(b[i]-a[i]);
		}//end for 
	
	//something else:
	var rand = new Random();
	Func<vector> randomx1 = delegate() {
		vector x = new vector(a.size);
		for(int i = 0; i < x.size; i++) {
			x[i] = a[i] + rand.NextDouble()*(b[i] - a[i]);
			}//end for
		return x;
		};//end func..

	double sum=0; double sum2=0; // sums...
	//sampling the integration area N times:
	for(int i=0; i<N; i++){
		vector v= randomx1(); // sampel
		sum=sum+f(v);
		sum2=sum2+f(v)*f(v); //updating sums
		}// end for

	double mean= sum/N; //mean value
	double SIGMA=Sqrt(sum2/N-mean*mean)/Sqrt(N); //the an estimate for the error
	return new vector(mean*vol, SIGMA*vol);
	}//end plainmc
	
	

}//end class montecarlo
