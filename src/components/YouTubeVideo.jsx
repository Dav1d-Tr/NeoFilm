import React from "react";

const YouTubeVideo = () => {
  return (
    <div className="w-full lg:max-w-[560px] max-w-80">
      <iframe
        src="https://www.youtube.com/embed/liGB1ssYn38?si=zsH0cWt_afj1KEwr"
        title="YouTube video player"
        className="w-full aspect-video rounded-xl shadow-lg"
        frameBorder="0"
        allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
        referrerPolicy="strict-origin-when-cross-origin"
        allowFullScreen
      ></iframe>
    </div>
  );
};

export default YouTubeVideo;
