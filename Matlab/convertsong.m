
function [music,tempo] = convertsong(song,fs)
    [song,fs] = audioread('05.wav');
    points = timeout(song,fs);
    
    
   % points/44100
    %frequencies = findfrequencies(song,fs,points);
    %notes = frequencyToNote(frequencies);
   % size(notes)
    % [music,tempo] = noteDuration(points,notes,fs)
    
    
    dt(1) = points(1)/44100;
    
    for i=2:length(points)
        dt(i) = points(i)/44100 - points(i-1)/44100;
    end
    
    
   %axis([-5 5 -5 5]);
%plot(0,0,'or','MarkerSize',55);%'MarkerFaceColor','r');



close all;
disp('Wait 2 seconds:');
pause(2);

soundsc(song,fs,16);
t = cputime();

n=20;
col=hsv(n)
e=0;
i=1;
usertime=zeros(1,length(dt));
comptime=zeros(1,length(dt));
balls = 0;
e=0;

for i=1:length(dt)
    pause(dt(i)-e);
    t = cputime();
    j=mod(5*i+1,n)+1;
    plot(0,0,'or','MarkerSize',55,'MarkerFaceColor',col(j,:));
    hold on
    axis([-5 5 -5 5]);
    %pause(0.005);
    plot(0,0,'or','MarkerSize',55);
    axis([-5 5 -5 5]);
    e = cputime-t; 
end

clear sound;
balls
end
function onKeyPressRelease(evnt, pressRelease)
disp(evnt)
disp(pressRelease)
end


% end

% movie