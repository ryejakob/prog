using static System.Math;
using static System.Console;
using static matrix;
using static vector;
using static jac_dia;
using static jac_clas;
using static RandMatrix;
using System;

public class main{
	static int Main() {
	int nm=5;
	matrix A1=randmatrix_sym(nm,nm);
	//matrix V= new matrix(nm,nm);
	jac_dia jd=new jac_dia(A1);
	vector ed=jd.e;
	//matrix Ad=jd.A;
	jac_clas jc=new jac_clas(A1);
	vector ec=jc.e;
	matrix Ac=jc.A;

	WriteLine($"Part C:");
	WriteLine("i) Test that calculated eigenvalues with classic Jacobi are the same as the ones calulated by the cyclic sweep for a given random matrix A:");
	WriteLine($"Classic:	cyclic:");
	for(int n2=0;n2<nm; n2++){
		WriteLine($"{ec[n2]}	{ed[n2]}");
		}
	
	WriteLine("That the clissic method diagonalize a given matrix A:");
	for(int n1=0;n1<nm; n1++){
		for(int n2=0; n2<nm; n2++){
			Write($"{Ac[n1,n2]}	");
			}
		Write("\n");
		}

	WriteLine($"");
	WriteLine($"ii) Does classic improve the number of rotation and the time?");
	WriteLine($"In plot_rotations.svg and plot_time.svg is the number of rotations and the time used by the classic and the cyclic sweep methods compared.");
	WriteLine($"The result indicate that classic Jacobi is slower then the cyclic sweep, but use fewer rotations.");


	return 0;	
}}
