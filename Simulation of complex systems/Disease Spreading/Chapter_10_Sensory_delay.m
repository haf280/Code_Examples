%% Exercise 10.1: Simulation of a light-sensitive robot.
clc,clear all
gm = gmdistribution(0,1);
N=1e4;

x=zeros(1,N);
y=zeros(1,N);
I=zeros(1,N);
v=zeros(1,N);

tau=2;
phi=sqrt(2/tau)*random(gm,N);
dt=0.02;
vInf=0.05;
v0=2;
L=v0*tau;
lambda=2*L;
%%
for i=2:N    
    dx=v0*cos(phi(i))*dt;
    dy=v0*sin(phi(i))*dt;
    
    x(i)=x(i-1)+dx;
    y(i)=y(i-1)+dy;   
end

plot(x,y,'.')




%% 10.1b
for i=2:N
    
    I(i)=(sin(2*pi*i/lambda))^2;
    v(i)=vInf+(v0-vInf)*exp(-I(i));
    dx=v(i)*cos(phi(i))*dt;
    dy=v(i)*sin(phi(i))*dt;
    
    x(i)=x(i-1)+dx;
    y(i)=y(i-1)+dy;


end


plot(x,y,'.')





