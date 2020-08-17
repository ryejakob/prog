using static System.Math;
using static System.Console;
using static matrix;
using static vector;
using static jac_dia;
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
	int nr=0;
	vector e=jac_dia_red(A1,V,N, ref nr);

	WriteLine($" {nr}");
	
	


	return 0;	
}}
