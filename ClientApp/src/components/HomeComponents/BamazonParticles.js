import React, { useEffect, useState, useRef } from 'react';
import './ParticleAnimation.css';

function BamazonParticles() {
    const canvasRef = useRef(null);
    const [particlePositions, setParticlePositions] = useState([]);

    useEffect(() => {
        const canvas = canvasRef.current;
        const ctx = canvas.getContext('2d');
    
        ctx.font = "120px Arial";
        ctx.fillText("Bamazon", 10, 120);  // Adjusted vertical position
    

        const positions = [];
        const imageData = ctx.getImageData(0, 0, canvas.width, canvas.height);
        for (let x = 0; x < canvas.width; x += 2) {  // Sampling every 2 pixels
            for (let y = 0; y < canvas.height; y += 2) {  // Sampling every 2 pixels
                const i = (y * 4) * canvas.width + x * 4;
                const alpha = imageData.data[i + 3];
                if (alpha > 128) {
                    positions.push({ x, y });
                }
            }
        }

        const particles = positions.map(pos => ({
            startX: Math.random() * canvas.width,
            startY: Math.random() * canvas.height,
            targetX: pos.x,
            targetY: pos.y
        }));

        setParticlePositions(particles);
    }, []);

    return (
        <div className="particleContainer">
            {particlePositions.map((particle, index) => (
                <div 
                    key={index} 
                    className="particle"
                    style={{
                        '--startX': particle.startX + 'px',
                        '--startY': particle.startY + 'px',
                        '--targetX': particle.targetX + 'px',
                        '--targetY': particle.targetY + 'px'
                    }}
                ></div>
            ))}
            <canvas ref={canvasRef} style={{ display: 'none' }} width="800" height="200"></canvas>
        </div>
    );
}

export default BamazonParticles;
