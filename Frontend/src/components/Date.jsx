import React from 'react'

const Date = ({ date, time }) => {
  return (
    <article className='bg-gray-200 rounded-lg p-2 shadow-lg shadow-gray-900 text-black px-4'>
        <em>{date}</em> • <span>{time}</span>
    </article>
  )
}

export default Date