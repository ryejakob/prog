all: plotA.svg outA.txt test.txt

plotA.svg: plot.gpi data.txt
	gnuplot $<

outA.txt test.txt data.txt: main.exe 
	mono $< 1> outA.txt

main.exe : main.cs jac_dia.dll matrix.dll vector.dll RandMatrix.dll
	mcs -reference:RandMatrix.dll -reference:jac_dia.dll -reference:matrix.dll -reference:vector.dll main.cs

jac_dia.dll: jac_dia.cs vector.dll matrix.dll
	mcs -reference:vector.dll -reference:matrix.dll -target:library -out:$@ $<

RandMatrix.dll: RandMatrix.cs vector.dll matrix.dll
	mcs -reference:vector.dll -reference:matrix.dll -target:library -out:$@ $<

matrix.dll: matrix.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<

.PHONY:clean
clean:
	rm -f *.dll *.exe *.txt *.svg 
