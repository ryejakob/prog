using static fun;

static class main{
	static void Main(){
			double x_step=125;		
			for(double x=0; x<=2000; x+= x_step){
			System.Console.WriteLine($"{x} {lngamma(x)}");
			}
	}
}
