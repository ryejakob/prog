using static System.Math;
using static System.Console;
using static gram_s;
using static matrix;
using static vector;

public class main{
	static int Main() {
	
	matrix A = new matrix(3,3);
	
	A[0,0]=1; A[0,1]=2;A[0,2]=3;
	A[1,0]=2; A[1,1]=3;A[1,2]=5;
	A[2,0]=1; A[2,1]=1;A[2,2]=4;
	//A[3,0]=2; A[3,1]=3;A[3,2]=3;


	
	gram_s a1 = new gram_s(A);

	matrix B=a1.inverse();
	matrix ab=A*B;

	WriteLine("B-matrix takes the form:");
	for(int i=0; i<B.size1; i++){
		Write("\n");
		for(int n1=0; n1<B.size2; n1++){
		Write($"{B[i,n1]} ");
		}
	} Write("\n");
	WriteLine("AB-matrix:");
	for(int i=0; i<ab.size1; i++){
		Write("\n");
		for(int n1=0; n1<ab.size2; n1++){
		Write($"{ab[i,n1]} ");
		}
	} Write("\n");
	
	return 0;	
}}
