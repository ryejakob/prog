all: outB.txt 

plotB.svg: plot.gpi data.txt 
	gnuplot $<

outB.txt: main.exe
	mono main.exe> $@ 

main.exe: main.cs integrator.dll vector.dll quado8.dll
	mcs -reference:integrator.dll -reference:vector.dll -reference:quado8.dll main.cs

quado8.dll: quado8.cs
	mcs -target:library -out:$@ $<

integrator.dll: integrator.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<

clean: ; $(RM) *.dll *.exe *.txt *.svg 
