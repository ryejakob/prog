all: Linear_splineA.svg Linear_integralA.svg

Linear_integralA.svg: plot2.gpi data.txt
	gnuplot $<

Linear_splineA.svg: plot.gpi data.txt points.txt
	gnuplot $<

outA.txt points.txt data.txt: main.exe
	mono $< 1> outA.txt

main.exe: main.cs interpol.dll vector.dll
	mcs -reference:interpol.dll -reference:vector.dll -out:main.exe main.cs

interpol.dll: interpol.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<

.PHONY:clean
clean:
	rm -f *.dll *.exe out.*.txt *.svg 
