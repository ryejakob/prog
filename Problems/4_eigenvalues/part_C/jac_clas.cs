using static System.Math;
using static matrix;
using static vector;

public class jac_clas{

public int n_rot;
public vector e;
public matrix A,V;

//function that takes gives the indices of the larges element from a given row of a matrix
public static int seach_lar_row(int ro, matrix A1){
	matrix a=A1.copy();
	double co_val=a[ro,ro+1];
	int co=ro+1;
	for(int n=ro+2; n<a.size1; n++){
		if(Abs(a[ro,n])>Abs(co_val)){
		co_val=a[ro,n];
		co=n;
		}//end if
		}//end for
	return co;
}//seach

//function that gives the index corresponding to larges element:
public static int seach_index(int[] index, matrix A1){
	matrix a=A1.copy();
	double val=a[0,index[0]];
	int i_max=0;
	for(int n=0;n<a.size1-2; n++){
		if(a[n,index[n]]>val){
		val=a[n,index[n]];
		i_max=n;
		}//end if
		}//end for
	return i_max;
}//seach

//constructor	
public jac_clas(matrix A1){
	int row=A1.size1;
	matrix a=A1.copy();
	//array with indices of the lagest element in the rows..
	int[] index= new int[row-1];
	for(int n1=0; n1<row-1; n1++){
		index[n1]=seach_lar_row(n1,a);
		}//end for
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
	for(int p=0; p<row-1; p++){
	
	//int p=seach_index(index,a);
	int q=index[p];
	double the= Atan2(2*a[p,q],dia[q]-dia[p])/2;
		double apq=a[p,q];
		double app=dia[p];
		double aqq=dia[q];
		a[p,q]=0;//Sin(the)*Cos(the)*(dia[p]-dia[q])+(Pow(Cos(the),2) - Pow(Sin(the),2))*a[p,q];
		dia1[p]=Pow(Cos(the),2)*app - 2*Sin(the)*Cos(the)*apq + Pow(Sin(the),2)*aqq;
		dia1[q]=Pow(Sin(the),2)*app + 2*Sin(the)*Cos(the)*apq + Pow(Cos(the),2)*aqq; 
		if(dia1[p]!=dia[p] || dia1[q]!=dia[q]){
		//	cha=true;
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
	//updating the index array for the given row
	index[p]=seach_lar_row(p,a);
	}// end if
	}//end for 
	//System.Console.Error.WriteLine("tjek");
	}while(k>0);
	// result
	e=dia;
	V=V1;
	A=a;
	n_rot=nr; 
	}// end construtor
















}//end class 
