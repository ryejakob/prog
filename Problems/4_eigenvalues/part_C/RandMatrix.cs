using System;
using static matrix;
using static System.Math;

public class RandMatrix{

//public Random ra=new Random(); //field...

//functions
public static matrix randmatrix(int n, int m){
	matrix A=new matrix(n,m);
	Random ra=new Random();
	for(int n1=0; n1<n; n1++){
		for(int m1=0; m1<m; m1++){
			A[n1,m1]=ra.NextDouble();
			}
		}
	return A;
}//end randmatrix

public static matrix randmatrix_sym(int n, int m){ 
	matrix A=new matrix(n,m);
	Random ra=new Random();
	//diagonal
	for(int n1=0; n1<n;n1++){
		A[n1,n1]=ra.NextDouble();
		}// end for
	for(int n2=1; n2<n; n2++){
		for(int n3=0; n3<n2;n3++){ 
			A[n2,n3]=ra.NextDouble();
			A[n3,n2]=A[n2,n3];
			}
		}
	return A; 
} // end ransmatrix_sys




}//end class
