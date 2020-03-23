using static matrix;
using static System.Math;
using System;

public class gram_s{

	//public matrix Q{get{return a;}}
	//public matrix R{get{return R1;}}	

	public readonly matrix R;
	public readonly matrix Q;

	public gram_s(matrix A){ 
	matrix a=A.copy();
	int rows_A=A.size1;
	int columns_A=A.size2;
	matrix q=new matrix(rows_A, columns_A);
	if(rows_A<columns_A){
	Console.Error.WriteLine("Error!!! Matrix A has more columns then rows, try transposing A |\n Error!! \n Error!!!");
	}//end if
	else{
	matrix R1 = new matrix(columns_A,columns_A);
		//somthing else...		
		for(int n=0; n<columns_A; n++){
		R1[n,n]=Sqrt(col_ip(a,n,a,n));
		a[n]=a[n]/R1[n,n];
			//for(int n1=0; n1<rows_A; n1++){	
			//a[n1,n]=a[n1,n]/R1[n,n];
			//}//end for

			for(int n2=n+1; n2<columns_A; n2++){
			R1[n,n2]= col_ip(a,n,a,n2);
				for(int n3=0; n3<rows_A; n3++){
				a[n3,n2]=a[n3,n2]-a[n3,n]*R1[n,n2];
				}//end for
			}//end for
		}//end for

	R=R1;
	Q=a;

	}//end else

	// this does not work... I will try somthing else ...
	//for(int n=0; n<columns_A; n++){
	//double rnn= Sqrt(col_ip(a,n,a,n)) ;
	//R1[n,n]=Sqrt(rnn);
	//	for(int n1=0; n1<rows_A; n1++){
	//	q[n1,n]=a[n1,n]/rnn;
	//	}// end for
	
	//	for(int j=n+1; j<columns_A; j++){
	//	R1[n,j]=col_ip(q,n,a,j);
	//		for(int n2=0; n2< rows_A; n2++){
	//		a[n2,j]=a[n2,j]-R1[n,j]*q[n2,n];
	//		}//end for
	
	//	}//end for
	
	//}//end for 
 	//R=R1;
	//Q=q;
	//}//end else
	
	
	}// end constructor



	public static double col_ip(matrix A, int col_A, matrix B, int col_B){
		matrix a=A.cols(col_A,col_A);
		matrix b=B.cols(col_B,col_B);
		matrix c=a.T*b; 
		return c[0,0]; 
	}
	//for some reason the following does not seem to work as intended.. so once again I try somthing different...
	public static vector qr_gs_solve(matrix Qn, matrix Rn, vector b){
		vector qtb=Qn.T*b; 
		int m=qtb.size;
		for(int n=m-1; n>=0; n--) {
		double sum=0;
			for(int i=n+1; i<m; i++){
			sum=sum+qtb[i]*Rn[n,i];
			qtb[n]=(qtb[n]-sum)/Rn[n,n];
			}//end for
		
		}//end for
		return qtb;
	}

	//somthing different...
public void back_s(vector v){
	int m=v.size;
	for(int n=m-1; n>=0; n--){
	double sum=0;
		for(int n2=n+1; n2<m; n2++){
		sum=sum+R[n,n2]*v[n2];
		}//end for
		v[n]=(v[n]-sum)/R[n,n];
	}//end for
}//end back_s...

public vector solve(vector w){
	vector vec=Q.T*w;
	back_s(vec);
	return vec;
	}//end solve...
	



}
