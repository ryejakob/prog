using static System.Math;
using static matrix;

//only for square sysmetic matrix...
public class jac_dia{

public int n_rot;
public vector e;
public matrix A,V;

//constructor
public jac_dia(matrix A1){
	int row=A1.size1;
	matrix a=A1.copy();
	//int col=A.size2;
	vector dia=new vector(row); 
	vector dia1=new vector(row);
	matrix V1=new matrix(row,row);
	int nr=0;
	for(int n=0; n<row; n++){ 
		dia[n]=a[n,n];
		V1[n,n]=1;
		}//end for 
	//first iteration:
	double k;
	do{
	//cha=false;
	k=0;
	for(int q=row-1; q>0; q--){
		for(int p=0; p<q; p++){
			double the= Atan2(2*a[p,q],dia[q]-dia[p])/2;
			double apq=a[p,q];
			double app=dia[p];
			double aqq=dia[q];
			a[p,q]=0;//Sin(the)*Cos(the)*(dia[p]-dia[q])+(Pow(Cos(the),2) - Pow(Sin(the),2))*a[p,q];
			dia1[p]=Pow(Cos(the),2)*app - 2*Sin(the)*Cos(the)*apq + Pow(Sin(the),2)*aqq;
			dia1[q]=Pow(Sin(the),2)*app + 2*Sin(the)*Cos(the)*apq + Pow(Cos(the),2)*aqq;
			//a[p,q]=apq; dia1[p]=app; dia1[q]=aqq;
			if(dia1[p]!=dia[p] || dia1[q]!=dia[q]){
				//cha=true;
				k=k+1;nr++;
			dia[p]=dia1[p];
			dia[q]=dia1[q];		
			for(int n1=0; n1<p; n1++){
				double anp=a[n1,p];
				double anq=a[n1,q];
				a[n1,p]=Cos(the)*anp-Sin(the)*anq;
				a[n1,q]=Sin(the)*anp+Cos(the)*anq;
				}// end for
			for(int n2=p+1; n2<q; n2++){ 
				double apn=a[p,n2];
				double anq=a[n2,q];
				a[p,n2]=Cos(the)*apn-Sin(the)*anq;
				a[n2,q]=Sin(the)*apn+Cos(the)*anq;
				}//end for
			for(int n3=q+1; n3<row; n3++){
				double apn=a[p,n3];
				double aqn=a[q,n3];
				a[p,n3]=Cos(the)*apn-Sin(the)*aqn;
				a[q,n3]=Sin(the)*apn+Cos(the)*aqn;
				}//end for
			//V matrix:
			for(int n4=0; n4<row; n4++){
				double vnp=V1[n4,p];
				double vnq=V1[n4,q]; 
				V1[n4,p]=Cos(the)*vnp-Sin(the)*vnq;
				V1[n4,q]=Sin(the)*vnp+Cos(the)*vnq;
				}//end for
			}//end if
			}// end for
		
		}//end for
	
	}while(k>0);
	// result
	e=dia;
	V=V1;
	A=a; 
	n_rot=nr;
	}// end construtor

public static vector jac_dia_red(matrix A2, matrix V2, int n_e, ref int nnew){
	int row=A2.size1;
	matrix a=A2.copy();
	//int col=A.size2;
	vector dia=new vector(row); 
	vector dia1=new vector(row);
	matrix V1=new matrix(row,row);
	bool cha;
	for(int n=0; n<row; n++){ 
		dia[n]=a[n,n];
		V1[n,n]=1;
		}//end for 
	//first iteration:
	
	//for(int q=row-1; q>0; q--){
	//	for(int p=0; p<q; p++){
	for(int p=0; p<n_e; p++){
		do{
		cha=false;
		for(int q=p+1; q< row; q++){
			double the= Atan2(2*a[p,q],dia[q]-dia[p])/2;
			double apq=a[p,q];
			double app=dia[p];
			double aqq=dia[q];
			a[p,q]=0;//Sin(the)*Cos(the)*(dia[p]-dia[q])+(Pow(Cos(the),2) - Pow(Sin(the),2))*a[p,q];
			dia1[p]=Pow(Cos(the),2)*app - 2*Sin(the)*Cos(the)*apq + Pow(Sin(the),2)*aqq;
			dia1[q]=Pow(Sin(the),2)*app + 2*Sin(the)*Cos(the)*apq + Pow(Cos(the),2)*aqq;
			//a[p,q]=apq; dia1[p]=app; dia1[q]=aqq;
			if(dia1[p]!=dia[p] || dia1[q]!=dia[q]){
				cha=true;
				nnew++;
				}
			dia[p]=dia1[p];
			dia[q]=dia1[q];		
			for(int n1=0; n1<p; n1++){
				double anp=a[n1,p];
				double anq=a[n1,q];
				a[n1,p]=Cos(the)*anp-Sin(the)*anq;
				a[n1,q]=Sin(the)*anp+Cos(the)*anq;
				}// end for
			for(int n2=p+1; n2<q; n2++){ 
				double apn=a[p,n2];
				double anq=a[n2,q];
				a[p,n2]=Cos(the)*apn-Sin(the)*anq;
				a[n2,q]=Sin(the)*apn+Cos(the)*anq;
				}//end for
			for(int n3=q+1; n3<row; n3++){
				double apn=a[p,n3];
				double aqn=a[q,n3];
				a[p,n3]=Cos(the)*apn-Sin(the)*aqn;
				a[q,n3]=Sin(the)*apn+Cos(the)*aqn;
				}//end for
			//V matrix:
			for(int n4=0; n4<row; n4++){
				double vnp=V1[n4,p];
				double vnq=V1[n4,q]; 
				V1[n4,p]=Cos(the)*vnp-Sin(the)*vnq;
				V1[n4,q]=Sin(the)*vnp+Cos(the)*vnq;
				}//end for
			}// end for
		}while(cha);
		}//end for
	
	// result
	//e=dia;
	V2=V1;
	A2=a;
	//n_rot=nr;
	return dia; 
	}
public static vector jac_dia_high_e(matrix A2, matrix V2, int n_e, ref int nnew){
	int row=A2.size1;
	matrix a=A2.copy();
	//int col=A.size2;
	vector dia=new vector(row); 
	vector dia1=new vector(row);
	matrix V1=new matrix(row,row);
	bool cha;
	for(int n=0; n<row; n++){ 
		dia[n]=a[n,n];
		V1[n,n]=1;
		}//end for 
	//first iteration:
	
	//for(int q=row-1; q>0; q--){
	//	for(int p=0; p<q; p++){
	for(int p=0; p<n_e; p++){
		do{
		cha=false;
		for(int q=p+1; q< row; q++){
			double the= Atan2(-2*a[p,q],dia[p]-dia[q])/2; 
			double apq=a[p,q];
			double app=dia[p];
			double aqq=dia[q];
			a[p,q]=0;//Sin(the)*Cos(the)*(dia[p]-dia[q])+(Pow(Cos(the),2) - Pow(Sin(the),2))*a[p,q];
			dia1[p]=Pow(Cos(the),2)*app - 2*Sin(the)*Cos(the)*apq + Pow(Sin(the),2)*aqq;
			dia1[q]=Pow(Sin(the),2)*app + 2*Sin(the)*Cos(the)*apq + Pow(Cos(the),2)*aqq;
			//a[p,q]=apq; dia1[p]=app; dia1[q]=aqq;
			if(dia1[p]!=dia[p] || dia1[q]!=dia[q]){
				cha=true;
				nnew++;
				}
			dia[p]=dia1[p];
			dia[q]=dia1[q];		
			for(int n1=0; n1<p; n1++){
				double anp=a[n1,p];
				double anq=a[n1,q];
				a[n1,p]=Cos(the)*anp-Sin(the)*anq;
				a[n1,q]=Sin(the)*anp+Cos(the)*anq;
				}// end for
			for(int n2=p+1; n2<q; n2++){ 
				double apn=a[p,n2];
				double anq=a[n2,q];
				a[p,n2]=Cos(the)*apn-Sin(the)*anq;
				a[n2,q]=Sin(the)*apn+Cos(the)*anq;
				}//end for
			for(int n3=q+1; n3<row; n3++){
				double apn=a[p,n3];
				double aqn=a[q,n3];
				a[p,n3]=Cos(the)*apn-Sin(the)*aqn;
				a[q,n3]=Sin(the)*apn+Cos(the)*aqn;
				}//end for
			//V matrix:
			for(int n4=0; n4<row; n4++){
				double vnp=V1[n4,p];
				double vnq=V1[n4,q]; 
				V1[n4,p]=Cos(the)*vnp-Sin(the)*vnq;
				V1[n4,q]=Sin(the)*vnp+Cos(the)*vnq;
				}//end for
			}// end for
		}while(cha);
		}//end for
	
	// result
	//e=dia;
	V2=V1;
	A2=a;
	return dia; 
	}	

}// end class

