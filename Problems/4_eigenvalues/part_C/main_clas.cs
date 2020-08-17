using static System.Math;
using static System.Console;
using static matrix;
using static vector;
using static jac_clas;
using static RandMatrix;
using System;

public class main{
	static int Main(string[] args) {
	int N;
	if (args.Length > 0){ N = int.Parse(args[0]);}
	else { N=3;}
	int nm=N;
	matrix A1=randmatrix_sym(nm,nm);
	matrix V= new matrix(nm,nm);
	//vector e=jac_dia_red(A1,V,1);

	jac_clas ja=new jac_clas(A1);
	int nr=ja.n_rot;

	WriteLine($"{nm} {nr}");
	
	


	return 0;	
}}
