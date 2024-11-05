import { Link } from 'react-router-dom';
import s from './Header.module.css';
import { Outlet } from 'react-router-dom';
import ProfileDropdown from './ProfileDropdown';
import { useState } from 'react';
const Header = () => {
    const headerLinks = [
        { link: '/benefits/all', text: 'Все льготы', iconSrc: '/grid.svg' },
        { link: '/benefits/my', text: 'Мои льготы', iconSrc: '/check-mark.svg' },
        { link: '/benefits/new', text: 'История льгот', iconSrc: '/collection.svg' },
        { link: '/benefits/requested', text: 'Мои заявки', iconSrc: '/book.svg' },
    ];
    const [isVisible, setVisible] = useState(false);
    const handleProfileDropdown = () => {
        setVisible(!isVisible);
    };
    return (
        <>
            <header className={s.header}>
                <div className={`flex ${s.header_container}`}>
                    <img className={s.logo} src='/udv-logo.svg' alt='Логотип UDV' />
                    <ul className={`flex ${s.nav}`}>
                        {headerLinks.map(item => {
                            return (
                                <li
                                    className={`flex ${s.nav_item}`}
                                    key={headerLinks.indexOf(item)}>
                                    <img
                                        className={s.nav_link_icon}
                                        src={item.iconSrc}
                                        alt='Иконка)'
                                    />
                                    <Link to={item.link} className={`flex ${s.nav_link}`}>
                                        {item.text}
                                    </Link>
                                </li>
                            );
                        })}
                    </ul>
                    <ul className={`flex ${s.header_left}`}>
                        <li className={s.header_left_item}>
                            <button>
                                <img src='/burger.svg' alt='#' />
                            </button>
                        </li>
                        <li className={s.header_left_item}>
                            <button>
                                <img src='/bell.svg' alt='#' />
                            </button>
                        </li>
                        <li className={s.header_left_item}>
                            <button onClick={handleProfileDropdown}>
                                <img src='/profile.svg' alt='#' />
                            </button>
                            {isVisible && <ProfileDropdown />}
                        </li>
                    </ul>
                </div>
            </header>
            <Outlet />
        </>
    );
};
export default Header;
