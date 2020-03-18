using static fun;
using static cmath;
using static System.Math;

static class main{
	static void Main(){
			double x_step=0.1;		
			for(double x=-4; x<=4; x+= x_step){
				for(double y=-4; y<=4; y+=x_step){
					complex z=new complex (x, y);
			System.Console.WriteLine($"{x} {y} {abs(gamma(z))}");
			}
			}
	}
}
