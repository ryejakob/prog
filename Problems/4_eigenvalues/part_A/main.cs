using static System.Math;
using static System.Console;
using static matrix;
using static vector;
using static jac_dia;
using static RandMatrix;
using System;

public class main{
	static int Main() {

	//testing the Jacobi dia..

	WriteLine("Part A:");
	WriteLine("i) Test of Jacobi diagonalization with cyclic sweeps:");
	WriteLine("In the file test.txt the implementation is tested for a random sysmetic matrix.");

	var test=new System.IO.StreamWriter("test.txt");
	int nm=4; //matrix size
	matrix A1=randmatrix_sym(nm,nm); //random matrix

	jac_dia ja= new jac_dia(A1); //diagonalization
	
	matrix A=ja.A;
	matrix D= new matrix(A.size1,A.size2); 
	vector e = ja.e;
	for(int n=0; n<A.size1; n++){
		D[n,n]=e[n];
		}
	matrix V= ja.V;
	matrix vdvt= V*D*V.T;
	matrix vtav= V.T*A1*V;


	test.WriteLine("Test ofJacobi diagonalization with cyclic sweeps.");
	test.WriteLine($"");
	test.WriteLine("Random symmetric matrix A:");
	for(int n1=0; n1<A.size1; n1++){
		for(int n2=0; n2<A.size1; n2++){
			test.Write($"{A1[n1,n2]}	");
			}
		test.Write("\n \n");
		}
	

	test.WriteLine("Reduced matrix A:");
	for(int n1=0; n1<A.size1; n1++){
		for(int n2=0; n2<A.size1; n2++){
			test.Write($"{A[n1,n2]}	");
			}
		test.Write("\n \n");
		}
	test.WriteLine("the Diagonal matrix with the corresponding eigenvaluesmatrix D:");
	for(int n1=0; n1<A.size1; n1++){
		for(int n2=0; n2<A.size1; n2++){
			test.Write($"{D[n1,n2]}	");
			}
		test.Write("\n \n");
		}
	test.WriteLine("The orthogonal matrix of eigenvectorsmatrix V:");
	for(int n1=0; n1<A.size1; n1++){
		for(int n2=0; n2<A.size1; n2++){
			test.Write($"{V[n1,n2]}	");
			}
		test.Write("\n \n");
		}
	test.WriteLine("Test VDVT=A... VDVT is given as:");
	for(int n1=0; n1<A.size1; n1++){
		for(int n2=0; n2<A.size1; n2++){
			test.Write($"{vdvt[n1,n2]}	");
			}
		test.Write("\n \n");
		}
	test.WriteLine("Test VTAV=D... VTAV is given as:");
	for(int n1=0; n1<A.size1; n1++){
		for(int n2=0; n2<A.size1; n2++){
			test.Write($"{vtav[n1,n2]}	");
			}
		test.Write("\n");
		}
	test.Close();

	//particle in box:
	//build H
	int nh=50;
	double s=1.0/(nh+1);
	matrix H = new matrix(nh,nh);
	for(int i=0;i<nh-1;i++){
  		matrix.set(H,i,i,-2);
  		matrix.set(H,i,i+1,1);
  		matrix.set(H,i+1,i,1);
  		}//end for
	matrix.set(H,nh-1,nh-1,-2);
	matrix.scale(H,-1/s/s);
	
	//diagonalize H

	jac_dia jah=new jac_dia(H);
	//matrix H_dia=jah.A;
	vector eh= jah.e;
	matrix Vh= jah.V;

	WriteLine("ii) Particle in a box.");
	WriteLine("The following is a comparison between the first 5 the caculated and exact energies:");
	WriteLine("Number:	Calculated: 	Exact:");
	//check energies
	for(int n1=0; n1<5; n1++){
		double exact = Pow(PI*(n1+1),2);
		WriteLine($"{n1}	{eh[n1]}		{exact}");
		}//end for

	WriteLine("");
	WriteLine("In plotA.svg the 5 lowest eigenfunctions are plotted. The result have same form as the analytic result.");

	var data=new System.IO.StreamWriter("data.txt");
	
	
	for(int k=0;k<(5+1); k++){
		data.Write($"{0}  ");
		}//end for
	data.Write("\n");
	for(int j=0; j<nh;j++){
		data.Write($"{(j+1.0)/(nh+1)}  ");
		for(int k=0; k<5; k++){
			data.Write($"{matrix.get(Vh,j,k)}  ");
			}//end for
		data.Write("\n");
		}// end for
	data.Write($"{1} ");
	for(int k=0;k<(5); k++){
		data.Write($"{0}  ");
		}//end for
	data.Close();

	
	return 0;	
}}
