all: comparison_to_modern_value.txt #plot.svg

comparison_to_modern_value.txt: main.exe
	mono main.exe > comparison_to_modern_value.txt

plot.svg: plot.gpi out.txt data.txt
	gnuplot $<

out.txt : main.exe 
	mono main.exe > out.txt

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
