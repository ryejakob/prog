all: plotB.svg out.txt

plotB.svg: plot.gpi out.data.txt
	gnuplot $<

out.txt out.data.txt: main.exe
	mono main.exe > out.txt

main.exe: main.cs vector.dll montecarlo.dll
	mcs -reference:vector.dll -reference:montecarlo.dll main.cs

montecarlo.dll:montecarlo.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

matrix.dll:matrix.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<

.PHONY:clean
clean:
	rm -f *.dll *.exe out.*.txt *.svg 
