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

	//Stratified sampling mc 
	public static vector SSmc(Func<vector,double> f, vector a, vector b, int N, double acc=1e-4){

	//sample N random points with plainmc:
	vector samp=plainmc(f, a, b, N);
	//check error:
	if(samp[1] <= acc){
		//accept average and error:
		return samp;
		}//end if
	else{
	
	int ih=0; //index for highest sub-var
	double hvar=0; //highest sub-var
	//subdivide the volume:
	for(int i=0; i<a.size; i++){
		vector vol2=b.copy();
		vol2[i]=vol2[i]-0.5*(b[i]-a[i]);
		//estimate the sub varians 
		vector sam1=plainmc(f, a, vol2, N/(a.size*2));
		vector sam2=plainmc(f, vol2, b, N/(a.size*2));
		//calculating the total sub-var:
		double subvar= (Pow(sam1[1],2)+Pow(sam2[1],2));
		//check if the sub-var is larger:
		if(subvar>hvar){
			ih=i;//update index
			hvar=subvar; //update value
			}//end if
		}//end for
	//make recursive call
	vector svol=b.copy();
	svol[ih]=svol[ih]-0.5*(b[ih]-a[ih]);
	vector svol2=a.copy();
	svol2[ih]=svol2[ih]+0.5*(b[ih]-a[ih]);
	vector re1=SSmc(f, a, svol, N/2, acc*Sqrt(N/2));
	vector re2=SSmc(f, svol2, b, N/2, acc*Sqrt(N/2));
	vector re=re1+re2;
	//System.Console.Error.WriteLine($"{re1[0]} {re2[0]} {ih}");
	return new vector(re[0],Pow(re[1],2)/(N*4));
	}//end else
	}//end SSmc
			
	
	

}//end class montecarlo
