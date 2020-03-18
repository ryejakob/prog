using static fun;

static class main{
	static void Main(){
			double x_step=0.125;		
			for(double x=-3; x<=3; x+= x_step){
			System.Console.WriteLine($"{x} {erf(x)}");
			}
	}
}
