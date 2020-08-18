all: plot.svg

plot.svg: plot.gpi out.txt
	gnuplot $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs fun.dll cmath.dll
	mcs -reference:fun.dll -reference:cmath.dll -out:$@ $<

fun.dll: fun.cs cmath.dll
	mcs -reference:cmath.dll -target:library -out:$@ $< 

cmath.dll : cmath.cs complex.cs 
	mcs -target:library -out:cmath.dll cmath.cs complex.cs

.PHONY:clean
clean:
	rm -f lib/*.dll  math.dll *.exe out.*.txt *.dat *.svg
