all: Lin_spl.svg Integ.svg

Integ.svg: plot_2.gpi out_2.txt cos_data.txt
	gnuplot $<

out_2.txt: main_2.exe sin_data.txt
	mono main_2.exe <sin_data.txt > $@ 

main_2.exe: main_2.cs interpol.dll vector.dll
	mcs -reference:interpol.dll -reference:vector.dll -out:main_2.exe main_2.cs

Lin_spl.svg: plot.gpi out.txt sin_data_fine.txt
	gnuplot $<

out.txt : main.exe sin_data.txt
	mono main.exe <sin_data.txt > $@ 

main.exe: main.cs interpol.dll vector.dll
	mcs -reference:interpol.dll -reference:vector.dll -out:main.exe main.cs

interpol.dll: interpol.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<
