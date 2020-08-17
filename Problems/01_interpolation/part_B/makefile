all: quadratic_splineB.svg quadratic_derivativeB.svg quadratic_integralB.svg

quadratic_integralB.svg: plot3.gpi data.txt
	gnuplot $<

quadratic_derivativeB.svg: plot2.gpi data.txt
	gnuplot $<

quadratic_splineB.svg: plot.gpi data.txt points.txt
	gnuplot $<

outB.txt data.txt points.txt: main.exe
	mono $< 1> outB.txt

main.exe: main.cs qsline.dll vector.dll
	mcs -reference:qsline.dll -reference:vector.dll -out:main.exe main.cs

qsline.dll: qsline.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<

.PHONY:clean
clean:
	rm -f *.dll *.exe out.*.txt *.svg 
