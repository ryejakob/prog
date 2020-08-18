plot.svg: plot.gpi out.txt
	gnuplot $<

out.txt : main.exe 
	mono main.exe > out.txt

main.exe : main.cs quado8.dll fun_red.dll
	mcs -reference:quado8.dll -reference:fun_red.dll main.cs

quado8.dll : quado8.cs
	mcs -target:library -out:quado8.dll quado8.cs

fun_red.dll: fun_red.cs  
	mcs -target:library -out:$@ $< 

#cmath.dll : cmath.cs complex.cs 
#	mcs -target:library -out:cmath.dll cmath.cs complex.cs

clean:
	rm -f out.txt main.exe
