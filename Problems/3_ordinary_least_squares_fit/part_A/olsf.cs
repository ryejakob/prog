using static System.Math;
using static gram_s;
using static vector;
using static matrix;
using System;

public class olsf{

	public readonly vector c; //field

//constructor
//note to self: apparetly you can save functions as a array...
public olsf(vector x, vector y, vector dy, Func<double, double>[] f){
	int len=x.size;
	int m=f.Length;
	vector b=new vector(len);
	matrix A=new matrix(len, m);
		for(int n=0; n<len; n++){
		b[n]=y[n]/dy[n];
			for(int n1=0; n1<m; n1++){
			A[n,n1]=f[n1](x[n])/dy[n];
			}//end for
		}//end for
	gram_s gr=new gram_s(A);
	c= gr.solve(b);
	}//end constructor...


	

}//end class
	
