using static System.Math;
using static System.Console;
using static gram_s;
using static matrix;
using static vector;
using static RandMatrix;
using static gi_rot;

public class main{
	static int Main() {
	
	//generating a random matrix 
	matrix A = randmatrix(4,4);

	//givens:
	gi_rot a=new gi_rot(A);
	//grams-schmitt
	gram_s gs = new gram_s(A);

	//random vector b:
	vector b= randvector(4);

	//solve Ax=b using givens:
	vector x =a.solve(b);
	vector ax= A*x;
	
	WriteLine("Part C");
	WriteLine($"Givens rotation");
	WriteLine($"Random generated matrix A:");
	for(int i=0; i<A.size1; i++){
		Write("\n");	
		for(int j=0; j<A.size2; j++){
		Write($"{A[i,j]}	");
		}
	} Write("\n \n");
	WriteLine("The calculated matrix G, with stored rotation angles:");
	for(int i=0; i<a.A.size1; i++){
		Write("\n");	
		for(int j=0; j<a.A.size2; j++){
		Write($"{a.A[i,j]}	");
		}
	} Write("\n \n");
	WriteLine("R-matrix from Gram-Schmitt to comparison:");
	for(int i=0; i<gs.R.size1; i++){
		Write("\n");	
		for(int j=0; j<gs.R.size2; j++){
		Write($"{gs.R[i,j]}	");
		}
	} Write("\n \n");
	WriteLine("Note: the similarities between the upper triangle.");
	WriteLine("");
	WriteLine("Random vector b:");
	for(int i=0; i<b.size;i++){
		WriteLine($"{b[i]}");
		}//end for
	WriteLine(""); 
	WriteLine("Givens rotations was used to solve Ax=b, yielding x:");
	for(int i=0; i<x.size;i++){
		WriteLine($"{x[i]}");
		}//end for
	WriteLine("Ax gives:");
	for(int i=0; i<ax.size;i++){
		WriteLine($"{ax[i]}");
		}//end for
	WriteLine("Note: the same as b."); 	
	WriteLine("");
	 

	
	
	
	return 0;
}}
