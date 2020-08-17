all: outC.txt

plotS.svg: plotS.gpi data1.txt data2.txt data3.txt data4.txt
	gnuplot $<

outC.txt: main.exe
	mono main.exe> $@ 

main.exe: main.cs ode2.dll vector.dll
	mcs -reference:ode2.dll -reference:vector.dll main.cs

ode2.dll: ode2.cs matrix.dll vector.dll
	mcs -reference:matrix.dll -reference:vector.dll -target:library -out:$@ $<

RandMatrix.dll: RandMatrix.cs matrix.dll
	mcs -reference:matrix.dll -target:library -out:$@ $<

matrix.dll: matrix.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<

clean: ; $(RM) *.dll *.exe *.txt *.svg 
