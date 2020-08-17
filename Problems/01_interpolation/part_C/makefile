all: cubic_splineC.svg cubic_derivativeC.svg cubic_integralC.svg comparisonC.svg

comparisonC.svg: plot4.gpi plotutilsSpline.txt
	gnuplot $<

cubic_integralC.svg: plot3.gpi data.txt
	gnuplot $<

cubic_derivativeC.svg: plot2.gpi data.txt
	gnuplot $<

cubic_splineC.svg: plot.gpi data.txt points.txt
	gnuplot $<

plotutilsSpline.txt: points.txt
	spline $< > $@

outC.txt data.txt points.txt: main.exe
	mono $< 1> outC.txt

main.exe: main.cs csline.dll vector.dll
	mcs -reference:csline.dll -reference:vector.dll -out:main.exe main.cs

csline.dll: csline.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<

.PHONY:clean
clean:
	rm -f *.dll *.exe *.txt *.svg 
