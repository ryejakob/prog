all: plotC.svg outC.txt

plotC.svg: plot.gpi fit.txt data.txt
	gnuplot $<

outC.txt fit.txt data.txt: main.exe 
	mono $< 1> out.txt

main.exe : main.cs gram_s.dll matrix.dll vector.dll olsf.dll
	mcs -reference:olsf.dll -reference:gram_s.dll -reference:matrix.dll -reference:vector.dll main.cs

olsf.dll: olsf.cs gram_s.dll vector.dll matrix.dll
	mcs -reference:gram_s.dll -reference:vector.dll -reference:matrix.dll -target:library -out:$@ $<

gram_s.dll: gram_s.cs matrix.dll vector.dll
	mcs -reference:matrix.dll -reference:vector.dll -target:library -out:$@ $<

matrix.dll: matrix.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<

.PHONY:clean
clean:
	rm -f *.dll *.exe *.txt *.svg 
