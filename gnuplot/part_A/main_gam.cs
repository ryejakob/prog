using static fun;

static class main{
	static void Main(){
			double x_step=0.125;		
			for(double x=-5; x<=5; x+= x_step){
			System.Console.WriteLine($"{x} {gamma(x)}");
			}
	}
}
