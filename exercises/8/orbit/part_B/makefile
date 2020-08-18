all: plot_1.svg plot_2.svg plot_3.svg

plot_3.svg: plot_3.gpi out_3.txt 
	gnuplot $<

out_3.txt: main_3.exe
	mono $< > $@

main_3.exe: main_3.cs ode.dll vector.dll
	mcs -reference:ode.dll -reference:vector.dll main_3.cs

plot_2.svg: plot_2.gpi out_2.txt 
	gnuplot $<

out_2.txt: main_2.exe
	mono $< > $@

main_2.exe: main_2.cs ode.dll vector.dll
	mcs -reference:ode.dll -reference:vector.dll main_2.cs

plot_1.svg: plot_1.gpi out_1.txt 
	gnuplot $<

out_1.txt: main_1.exe
	mono $< > $@

main_1.exe: main_1.cs ode.dll vector.dll
	mcs -reference:ode.dll -reference:vector.dll main_1.cs

ode.dll: ode.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<
