
public struct vector3d : ivector3d {

private double a,b,c;

public double x{get{return a;}}
public double y{get{return b;}}
public double z{get{return c;}}

//constructors
public vector3d(double x,double y,double z){a=x;b=y;c=z;}

//operators
public static vector3d operator*(vector3d v, double c){return new vector3d(c*v.x,c*v.y,c*v.z);}
public static vector3d operator*(double c, vector3d v){return new vector3d(c*v.x,c*v.y,c*v.z);}
public static vector3d operator+(vector3d u, vector3d v){return new vector3d(u.x+v.x,u.y+v.y,u.z+v.z);}
public static vector3d operator-(vector3d u, vector3d v){return new vector3d(u.x-v.x,u.y-v.y,u.z-v.z);}
//methods
public static double dot_product(vector3d v, vector3d u){return v.x*u.x+v.y*u.y+v.z*u.z;} 
public static vector3d vector_product(vector3d v, vector3d u){return new vector3d(v.y*u.z-v.z*u.y, v.z*u.x-v.x*u.z, v.x*u.y-v.y*u.x);}
public static double magnitude(vector3d v){return System.Math.Sqrt( v.x*v.x+v.y*v.y+v.z*v.z );}
/*
public double xcor{
		get {return x;}
		set {x=value;}
}
public double ycor{
		get {return y;}
		set {y=value;}
}
public double zcor{
		get {return z;}
		set {z=value;}
}
*/
	

}
