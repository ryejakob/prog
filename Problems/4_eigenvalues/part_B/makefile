all: outB.txt plot_time.svg plot_rotation.svg

plot_time.svg: plot.gpi time_cyc.txt time_1_val.txt time_all_val.txt
	gnuplot $<

plot_rotation.svg: plot2.gpi rotation_cyc.txt rotation_1_val.txt rotation_all_val.txt
	gnuplot $<

outB.txt : main.exe time_cyc.txt
	mono main.exe <time_cyc.txt> $@ 

time_cyc.txt rotation_cyc.txt: main_cyc.exe
	for N in `seq 50 20 150`; do \
	echo "N=$$N";\
	\time -ao time_cyc.txt -f "$$N %U" mono main_cyc.exe $$N>> rotation_cyc.txt ; \
	done

time_1_val.txt rotation_1_val.txt: main_1_val.exe
	for N in `seq 50 20 150`; do \
	echo "N=$$N";\
	\time -ao time_1_val.txt -f "$$N %U" mono main_1_val.exe $$N>> rotation_1_val.txt ; \
	done

time_all_val.txt rotation_all_val.txt: main_all_val.exe
	for N in `seq 50 20 110`; do \
	echo "N=$$N";\
	\time -ao time_all_val.txt -f "$$N %U" mono main_all_val.exe $$N>> rotation_all_val.txt ; \
	done

main_all_val.exe : main_cyc.cs jac_dia.dll matrix.dll vector.dll RandMatrix.dll 
	mcs -reference:jac_dia.dll -reference:matrix.dll -reference:vector.dll -reference:RandMatrix.dll main_all_val.cs

main_1_val.exe : main_cyc.cs jac_dia.dll matrix.dll vector.dll RandMatrix.dll 
	mcs -reference:jac_dia.dll -reference:matrix.dll -reference:vector.dll -reference:RandMatrix.dll main_1_val.cs

main_cyc.exe : main_cyc.cs jac_dia.dll matrix.dll vector.dll RandMatrix.dll 
	mcs -reference:jac_dia.dll -reference:matrix.dll -reference:vector.dll -reference:RandMatrix.dll main_cyc.cs

main.exe: main.cs jac_dia.dll olsf.dll matrix.dll vector.dll RandMatrix.dll 
	mcs -reference:jac_dia.dll -reference:olsf.dll -reference:matrix.dll -reference:vector.dll -reference:RandMatrix.dll main.cs

jac_dia.dll: jac_dia.cs matrix.dll vector.dll
	mcs -reference:matrix.dll -reference:vector.dll -target:library -out:$@ $<

olsf.dll: olsf.cs matrix.dll vector.dll gram_s.dll
	mcs -reference:matrix.dll -reference:vector.dll -reference:gram_s.dll -target:library -out:$@ $<

gram_s.dll: gram_s.cs matrix.dll vector.dll
	mcs -reference:matrix.dll -reference:vector.dll -target:library -out:$@ $<

RandMatrix.dll: RandMatrix.cs matrix.dll
	mcs -reference:matrix.dll -target:library -out:$@ $<

matrix.dll: matrix.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<

clean: ; $(RM) *.dll *.exe time* *.svg *.txt
