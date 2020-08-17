all: akima_sin.svg akima_sin_derivative.svg akima_sin_integral.svg akima_step.svg

akima_step.svg: plotstep.gpi stepdata.txt stepp.txt
	gnuplot $<

akima_sin_integral.svg: plotsinint.gpi sindata.txt
	gnuplot $<

akima_sin_derivative.svg: plotsindif.gpi sindata.txt
	gnuplot $<

akima_sin.svg: plotsin.gpi sindata.txt sinp.txt
	gnuplot $<

out.txt sinp.txt sindata.txt stepdata.txt stepp.txt: main.exe
	mono $< 1> out.txt

main.exe: main.cs vector.dll akima.dll csline.dll
	mcs -reference:vector.dll -reference:akima.dll -reference:csline.dll main.cs

akima.dll: akima.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

csline.dll: csline.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<

.PHONY:clean
clean:
	rm -f *.dll *.exe out.*.txt *.svg 
