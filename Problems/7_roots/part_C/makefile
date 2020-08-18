all: out.txt plotC.svg

plotC.svg: plot.gpi plot1.txt
	gnuplot $<

out.txt: main.exe
	mono main.exe > out.txt

main.exe: main.cs newton.dll vector.dll ode2.dll
	mcs -reference:newton.dll -reference:vector.dll -reference:ode2.dll main.cs

newton.dll: newton.cs vector.dll matrix.dll gram_s.dll
	mcs -reference:vector.dll -reference:matrix.dll -reference:gram_s.dll -target:library -out:$@ $<

ode2.dll: ode2.cs vector.dll matrix.dll
	mcs -reference:vector.dll -reference:matrix.dll -target:library -out:$@ $<

gram_s.dll: gram_s.cs vector.dll matrix.dll
	mcs -reference:vector.dll -reference:matrix.dll -target:library -out:$@ $<

matrix.dll:matrix.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<

.PHONY:clean
clean:
	rm -f *.dll *.exe out.*.txt *.svg 
