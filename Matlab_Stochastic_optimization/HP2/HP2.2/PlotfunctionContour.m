function fig = PlotfunctionContour() % Return figure handle

x = linspace(-5,5);
y = linspace(-5,5);
[X,Y] = meshgrid(x,y);

term1 = (X.^2 + Y -11).^2;
term2 = (X+ Y.^2 - 7).^2;
Z= term1 + term2;
%ZLog =log(0.01+ term1 + term2);

range= linspace(-10,300,15);

for i=1:10
    subplot(2,5,i)
    contour(X,Y,Z,range);
end
fig=gcf;

end