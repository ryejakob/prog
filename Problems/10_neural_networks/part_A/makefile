all: plot.svg out.txt

plot.svg: plot.gpi out.data.txt
	gnuplot $<

out.txt out.data.txt: main.exe
	mono main.exe > out.txt

main.exe: main.cs vector.dll ann.dll
	mcs -reference:vector.dll -reference:ann.dll main.cs

ann.dll:ann.cs vector.dll mini.dll
	mcs -reference:vector.dll -reference:mini.dll -target:library -out:$@ $<

mini.dll: mini.cs vector.dll matrix.dll
	mcs -reference:vector.dll -reference:matrix.dll -target:library -out:$@ $<

matrix.dll:matrix.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<

.PHONY:clean
clean:
	rm -f *.dll *.exe out.*.txt *.svg 
