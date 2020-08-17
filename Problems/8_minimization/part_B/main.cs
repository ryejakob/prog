using System;
using static System.Math;
using static System.Console;
using static vector;
using static qNewton;

public class main{
	static int Main(string[] args) {
	// input to vector...
	var input = new System.IO.StreamReader("Data.txt");
	int input_lenght = 0;
	while(input.ReadLine() !=null) {
		input_lenght++; }
	input.Close();
	input = new System.IO.StreamReader("Data.txt");
	vector E = new vector(input_lenght);
	vector sig = new vector(input_lenght);
	vector err = new vector(input_lenght);
	
	string line;
	for(int n=0; n<input_lenght; n++){
		line = input.ReadLine();
		string[] words = line.Split(' ');
		E[n] = double.Parse(words[0]);
		sig[n] = double.Parse(words[1]);
		err[n] = double.Parse(words[2]);
	}
	//end input to vector...
	//new I have the data in 3 vectors E, sig and err...

	//the Breit-Wigner fuction:
	Func<double,vector,double> F = (x,v) => v[2]/(Pow(x-v[0],2)+v[1]*v[1]/4);//note: v[0]=m, v[1]=gamma and v[2]=A.. x=E

	//function D 
	Func<vector,double> Dfun= (v) => D(F, v, E, sig);
	
	// start guess 
	vector vst=new vector(124.0, 3, 5);

	double eps=1e-5; //accuracy
	
	int nr=0; //number of steps
	
	//using qnewton:
	vector mini=qnewton(Dfun, vst, eps, ref nr);

	WriteLine($"Part B:");
	WriteLine($"Fitting Higgs data to Breit-Wigner");
	WriteLine($"The minimization yeilds m={mini[0]}, Gamma={mini[1]} and A={mini[2]}, when used with the stating guess: m={vst[0]}, Gamma={vst[1]}, A={vst[2]} and accuracy goal eps={eps}. ");
	WriteLine($"The number of iterations was {nr}");

	//output to plot:
	var data=  new System.IO.StreamWriter("out.data.txt");
	for(double i=100; i<160; i=i+0.1){
		double Enew=mini[2]/(Pow(i-mini[0],2)+Pow(mini[1],2)/4);
		data.WriteLine($"{i}	{Enew}");
		} //end for
	data.Close();

	return 0;}

	//Function that takes breit-wigner, and return sum...
	public static double D(Func<double,vector,double> F, vector v, vector E, vector sig){
	double sum=0;
	for(int i=0; i<E.size; i++){
		sum= sum+Pow( F(E[i],v)-sig[i],2);
		}//end for
	return sum;
	}//end D


}
