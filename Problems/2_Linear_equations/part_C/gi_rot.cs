using static System.Math;
using static matrix;
using static vector;
using static System.Console;

public class gi_rot{

public matrix A;

//constructor
public gi_rot(matrix A1){
	matrix a=A1.copy();
	int row=a.size1;
	int col=a.size2;
		for(int n=0; n<col; n++){
			for(int n1=n+1; n1<row; n1++){
			double the=Atan2(a[n1,n],a[n,n]);
			//a[n]=a[n1]*Cos(the)+a[n]*Sin(the);
			//a[n1]=(-1)*a[n1]*Sin(the)+a[n]*Cos(the);
			//a[n, n1]=the;
				for(int n2=n; n2<col; n2++){
				double an_n2=a[n,n2];
				double an1_n2=a[n1,n2];
				a[n,n2]=an_n2*Cos(the)+an1_n2*Sin(the);
				a[n1,n2]=(-1)*an_n2*Sin(the)+an1_n2*Cos(the);
				}//end for
			
			a[n1,n]=the; 
			}//end for
		}//end for
	A=a;
	}//end constructor...

//methods:
public void back_s(vector v){
	int m=v.size;
		for(int n=m-1; n>=0; n--){
		double sum=0;
			for(int n2=n+1; n2<m; n2++){
			sum=sum+A[n,n2]*v[n2];
			}//end for
			v[n]=(v[n]-sum)/A[n,n];
		}//end for
	}//end back_s...

public vector solve(vector v){
	//constructing Gw=Q.T*w...
	vector w=v.copy();
	for(int q=0; q<A.size2; q++){
		for(int p=q+1; p<A.size1; p++){
			double the=A[p,q];
			double wp=w[p];
			double wq=w[q];
			w[q]=wq*Cos(the)+Sin(the)*wp;
			w[p]=-wq*Sin(the)+Cos(the)*wp;
			}//end for
		}//end for
	back_s(w);
	return w;
	}//end sove




}//end class
