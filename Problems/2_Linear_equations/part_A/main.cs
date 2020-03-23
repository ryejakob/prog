using static System.Math;
using static System.Console;
using static gram_s;
using static matrix;
using static vector;

public class main{
	static int Main() {
	
	matrix A = new matrix(4,3);
	
	A[0,0]=1; A[0,1]=2;A[0,2]=3;
	A[1,0]=2; A[1,1]=3;A[1,2]=5;
	A[2,0]=1; A[2,1]=1;A[2,2]=4;
	A[3,0]=2; A[3,1]=3;A[3,2]=3;


	
	gram_s a1 = new gram_s(A);

	matrix Q=a1.Q;
	matrix R=a1.R;
	
	WriteLine("Part 1");
	WriteLine("R-matrix takes the form:");
	for(int i=0; i<R.size1; i++){
		Write("\n");
		for(int n1=0; n1<R.size2; n1++){
		Write($"{R[i,n1]} ");
		}
	} Write("\n");

	WriteLine($"Test that Q^T*Q =1 :"); matrix qt=Q.T;
	matrix Q1=qt*Q;
	for(int i=0; i<Q1.size1; i++){
		Write("\n");
		for(int n1=0; n1<Q1.size2; n1++){
		Write($"{Q1[i,n1]} ");
		}
	} Write("\n");
	

	WriteLine("Test that QR=A");
	matrix Q2=Q*R;
	for(int i=0; i<Q2.size1; i++){
		Write("\n");
		for(int n1=0; n1<Q2.size2; n1++){
		Write($"{Q2[i,n1]} ");
		}
	} Write("\n");
	return 0;
}}
