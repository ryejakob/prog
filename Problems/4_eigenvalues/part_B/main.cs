using static System.Math;
using static System.Console;
using static matrix;
using static vector;
using static jac_dia;
using static RandMatrix;
using static olsf;
using System;

public class main{
	static int Main(string[] args) {
	// input to vector...
	var input = new System.IO.StreamReader("time_cyc.txt");
	int input_lenght = 0;
	while(input.ReadLine() !=null) {
		input_lenght++; }
	input.Close();
	input = new System.IO.StreamReader("time_cyc.txt");
	vector N = new vector(input_lenght);
	vector t = new vector(input_lenght);
	
	string line;
	for(int n=0; n<input_lenght; n++){
		line = input.ReadLine();
		string[] words = line.Split(' ');
		N[n] = double.Parse(words[0]);
		t[n] = double.Parse(words[1]);
	}
	//end input to vector...

	//using oslf to check O(n³)...
	//function to fit:
	var ft = new Func<double, double>[]{x=>1,x=>x};
	//error on time set to 1%:
	vector dt=new vector(t.size);
	vector lN=new vector(t.size);
	vector lt=new vector(t.size);
	for(int i=0; i<t.size;i++){
		lN[i]= Log(N[i]);
		lt[i]=Log(t[i]);
		dt[i]=lt[i]/100;
		}//end for
	//using olsf:
	
	olsf fit=new olsf(lN,lt, dt, ft);
	WriteLine("Part B:");
	WriteLine("");
	WriteLine("i) Check that the time goes as O(n³).");
	WriteLine($"By using my least square fit from Problem 3, i get that the time roughly depends of the matrix size N as t=N^(c), with c={fit.c[1]}.");
	WriteLine("");
	//check that eigenvalue by eigenvalue give same result as cyc

	//new random matrix:
	matrix A=randmatrix_sym(4,4);
	//using cyc:
	jac_dia ja=new jac_dia(A);
	int nr=0; //number of rotation:
	matrix V=new matrix(4,4);
	vector e1=jac_dia_red(A,V,4, ref nr);
	
	WriteLine("ii) Implement the value-by-value method"); 
	WriteLine("Check that the eigenvalues becomes the same as using cyclic sweeps.");
	WriteLine("Random generated symmetic matrix A:");

	for(int i=0; i<A.size1; i++){
		for(int k=0; k<A.size1; k++){
			Write($"{A[i,k]}	");
			}//end for
		Write("\n");
		}//end for
	Write("\n \n");
	
	WriteLine("Calutaled eigenvalues:");
	WriteLine("by cyclic:	by value-by-value:");
	
	for(int i=0;i<ja.e.size; i++){
		WriteLine($"{ja.e[i]}	{e1[i]}");
		}//end for
	
	WriteLine("");
	WriteLine("iii) and iv) Compare speed.");
	WriteLine("In plot_time.svg the time used by the cyclic sweeps method to calculate alle the eigenvalues, is compared to the time used by the value-by-value method to calculate the first and all eigenvalue(s).");
	WriteLine("It is faster to only calculate the first value by the value-by-value method then using cyclic sweeps. But cyclic sweeps is significant the calculated all eigenvalues by the value-by-value method.");
	WriteLine("In plot_rotation.svg the number of rotationes is compared.");
	WriteLine("");

	//largest eigenvalue
	matrix V2=new matrix(4,4);
	int nr2=0;
	vector eh =jac_dia_high_e(A, V2, 3, ref nr2);

	
	WriteLine($"v) Largest eigenvalue.");
	WriteLine($"By changing the theta angle from Atan2(2*Apq, Aq-Ap) to Atan2(-2*Apq, App-Aqq) the larges eigenvlaue can be calculated."); 
	WriteLine($"For vector A the value becomes: {eh[0]} the same as found by cyclic sweeps.");
	


	return 0;
	}// end Main
}//end class
