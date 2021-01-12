import React from 'react';
import { FiArrowLeft } from 'react-icons/fi';
import { useHistory } from 'react-router-dom';

import '../styles/components/header.css';

export default function Header(props) {
	const { goBack } = useHistory();
	return (
    <header className="header">
      <div className="top-bar-container">
        { props.goBack ? 
            <a onClick={goBack}>
              <FiArrowLeft size={35} color="#FFF" />
            </a>
          : null
        }
        <p>{props.title}</p>
      </div>
      <div className="header-content">
        <strong>{props.subtitle}</strong>
        <p>{props.description}</p>
      </div>
    </header>
	);
}