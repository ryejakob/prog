using static System.Math;
using static System.Console;
using static gram_s;
using static matrix;
using static vector;
using static RandMatrix;

public class main{
	static int Main() {
	
	//generating random matrix:
	matrix A = randmatrix(4,4);

	//fortorize into QR:
	gram_s a1 = new gram_s(A);

	//calculate inverse:
	matrix B=a1.inverse();
	//AB:
	matrix ab=A*B;

	WriteLine("Part B");
	WriteLine("Random matrix A:");
	for(int i=0; i<A.size1; i++){
		Write("\n");
		for(int j=0; j<A.size2; j++){
		Write($"{A[i,j]}	");
		}
	} Write("\n \n");
	WriteLine("Factorize A into QR, give Q:");
	for(int i=0; i<a1.Q.size1; i++){
		Write("\n");
		for(int j=0; j<a1.Q.size2; j++){
		Write($"{a1.Q[i,j]}	");
		}
	} Write("\n \n");
	WriteLine("and R:");
	for(int i=0; i<a1.R.size1; i++){
		Write("\n");
		for(int j=0; j<a1.R.size2; j++){
		Write($"{a1.R[i,j]}	");
		}
	} Write("\n \n");
	WriteLine("The inverse B:");
	for(int i=0; i<B.size1; i++){
		Write("\n");
		for(int j=0; j<B.size2; j++){
		Write($"{B[i,j]}	");
		}
	} Write("\n \n");
	WriteLine("AB:");
	for(int i=0; i<ab.size1; i++){
		Write("\n");
		for(int j=0; j<ab.size2; j++){
		Write($"{ab[i,j]}	");
		}
	} Write("\n \n");
	
	



	return 0;	
}}
