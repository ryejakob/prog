Exam project: Practical Programming and Numerical Methods 2020

By: Jakob Rye (student ID: 201303684)

Project: 18: Akima sub-spline 
	(since 84 mod 22 = 18)

The Akima sub-spline has been implemented as a class, named "Akima", in the file "akima.cs". The "Akima" class takes a constructor on the form: 
	public Akima(vector x, /* input vector x_i (must be sorted) */ 
	vector y, /* input vector y_i */
	vector dA1=null, /* optional, vector with one element; the derivative of the function at the first point x_1 */
	vector dA2=null, /* optional, vector with one element; the derivative of the function at the second point x_2 */
	vector dAn1=null, /* optional, vector with one element; the derivative of the function at the second to last point x_(n-1) */
	vector dAn=null /* optional, vector with one element; the derivative of the function at the last point x_1 */
	){ /*calculate a, b, c and d */ }

If no input is given the derivatives will be calculated as in equation (1.34) in the book.

Three methods was implemented in the class, all taking a double z as input: "spline", "derivative" and "integral". If z is inside the limets set by vector x, "spline" returns the value of the Akima sub spline, "derivative" returns the derivative of the spline and "integral" the integral from the first input point x[0] to the given z.

The sub-spline was tested on a sine-function: the resulting fit can be seen in "akima_sin.svg". 

The calculated derivative of the spline in "akima_sin.svg" is seen in "akima_sin_derivative.svg", and the anti-derivative (integral) of the spline in "akima_sin.svg" is seen in "akima_sin_integral".

In "akima_step.svg" Akima sub spine is compared to Cubic spline for the function f(x)=O(x-1)-O(x-2), where O(x) is the unity step function (or Heaviside step function). The plot illustrate the strength of the Akima sub-spline. 
