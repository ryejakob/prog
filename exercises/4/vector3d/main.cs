using System;
using static System.Console;
using static System.Math;
using static vector3d;



class main : ivector3d
{
	static int Main(){

		WriteLine("Part A:");
		WriteLine("Test of vector3d:");
		double c=2;
		double x=1; double y=1; double z=2;
		vector3d vec = new vector3d (x, y, z);
		vector3d vec2 = new vector3d (3, 2, 1);
		vector3d vec1 = c*vec;
		WriteLine($"v*c={vec1.x},{vec1.y},{vec1.z}");
		vector3d vecplu = vec + vec1;
		WriteLine($"v+v1={vecplu.x},{vecplu.y},{vecplu.z}");
		vector3d vecmin = vec1 - vec; 	
		WriteLine($"v-v1={vecmin.x},{vecmin.y},{vecmin.z}");
		WriteLine($"vdot={dot_product(vec,vec2)}");
		vector3d vecpru = vector_product(vec,vec2);
		WriteLine($"vpro={vecpru.x},{vecpru.y},{vecpru.z}");
		WriteLine($"mag={magnitude(vec)}");
	
		WriteLine("Part B:");
		WriteLine("Test ofproperties");
		WriteLine($"{vec2.x}");
		vec2.xcor = 1;
		WriteLine($"{vec2.x}");
		WriteLine($"{vec2.ycor}");

		
	return 0; }
}
