LIB= ../../lib

all: plot.svg out_log.txt

out_log.txt: main_log.exe
	mono $< > $@

main_log.exe: main_log.cs
	mcs main_log.cs

plot.svg: plot.gpi out.txt out_log.txt
	gnuplot $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs ode.dll vector.dll
	mcs -reference:ode.dll -reference:vector.dll main.cs

ode.dll: ode.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<
