public struct vector3d : ivector3d {

private double a,b,c;

public double x{get{return a;}}
public double y{get{return b;}}
public double z{get{return c;}}

public vector3d(double x,double y,double z){a=x;b=y;c=z;}

public void print(string s=""){
	System.Console.WriteLine($"{s} {this.x} {this.y} {this.z}");
	}

}
